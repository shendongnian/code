    public static anytype callMethod(str _className, str _methodName, container _parameters, Object _object = null)
    {
        DictClass dictClass;
        anytype returnValue;
        Object object;
        ExecutePermission permission; 
                 
        // Grants permission to execute the DictClass.callObject method. 
        // DictClass.callObject runs under code access security. 
        permission = new ExecutePermission();
        permission.assert(); 
        
        if (_object != null)
        {
            dictClass = new DictClass(classidget(_object));
            object = _object;
        }
        else
        {
            dictClass = new DictClass(className2Id(_className));
            object = dictClass.makeObject();
        }
        
        if (dictClass != null) 
        {
            switch (conLen(_parameters))
            {
                case 0:
                    returnValue = dictClass.callObject(_methodName, object);
                    break;
                case 1:
                    returnValue = dictClass.callObject(_methodName, object, conPeek(_parameters, 1));
                    break;
                case 2:
                    returnValue = dictClass.callObject(_methodName, object, conPeek(_parameters, 1), conPeek(_parameters, 2));
                    break;
                 //... Continue this pattern for the number of parameters you need to support.
            }
        }
    
        // Closes the code access permission scope. 
        CodeAccessPermission::revertAssert();
        
        return returnValue;
    }
