        private static void Test()
        {
            ocrVar ocrVar = new ocrVar();
            Type myType = ocrVar.GetType();
            PropertyInfo myPropInfo = myType.GetProperty("DueDate", BindingFlags.Static | BindingFlags.Public);
        }
