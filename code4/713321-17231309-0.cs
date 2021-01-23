    var typeOfT = userParam.getType();
        if (typeOfT == typeof(string))
        {
            return firstClass.GetEntity((string) userParam); //might have to do 'userParam as string' (im duck typing)
        }
        else if (typeOfT == typeof(int))
        {
            // call other GetEntity
        }
        else
        {
             //throw
        }
