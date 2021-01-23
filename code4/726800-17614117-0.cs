       public IMyInterface MyMethod()
            {
                Type type = MyItem.GetType(); // what happens here?
                IMyInterface value = (IMyInterface)Activator.CreateInstance(type);
                return value;
            }
