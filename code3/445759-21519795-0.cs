            IList list = (IList)value;// this what you need to do convert ur parameter value to ilist
            if (value == null)
            {
                return;//or throw an excpetion
            }
            Type magicType = value.GetType().GetGenericArguments()[0];//Get class type of list
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);//Get constructor reference
            
            if (magicConstructor == null)
            {
                throw new InvalidOperationException(string.Format("Object {0} does not have a default constructor defined", magicType.Name.ToString()));
            }
            object magicClassObject = magicConstructor.Invoke(new object[] { });//Create new instance
            if (magicClassObject == null)
            {
                throw new ArgumentNullException(string.Format("Class {0} cannot be null.", magicType.Name.ToString()));
            }
            list.Insert(0, magicClassObject);
            list.Add(magicClassObject);
         
