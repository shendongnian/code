    public Animal Feed(Food food)
        {
            var myType = this.GetType().FullName;
            if (food == null) return GetNewObject(myType + "NotFed") as Animal;
            if( food.GetType().FullName == myType+"Food") return GetNewObject(myType+"Fed") as Animal;
            return GetNewObject(myType+"BadFed") as Animal;
        }
        public static object GetNewObject(string typeName)
        {
            try
            {
                var t = Type.GetType(typeName);
                return t.GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
            catch
            {
                return null;
            }
        }
