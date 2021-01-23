    class My<T>
    {
        static bool doStuff()
        {
            var rightMehod = typeof(Helper).GetMethods().Where(p =>
                {
                    if (!p.Name.Equals("Can"))
                        return false;
                    if (!p.ReturnType.Equals(typeof(bool)))
                        return false;
                    if (p.GetParameters().Length != 1)
                        return false;
                    var par = p.GetParameters().First();
                    return par.ParameterType.Equals(typeof(T));
                }).FirstOrDefault();
            if (rightMehod == null)
            {
                return Helper.Can(default(T));
            }
            else
            {
                return (bool)rightMehod.Invoke(null, new object[] { default(T) });
            }
        }
        public static bool can = doStuff();
    }
