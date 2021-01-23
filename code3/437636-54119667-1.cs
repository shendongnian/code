    public class LocationTypeResolver : ITypeConverter<bob.sally,martin.sally>
    {
        public martin.sally Convert(bob.sally source, martin.sally destination, ResolutionContext context)
        {
            var retVal = new martin.sally
                         {
                             SomeValueVar = new object[source.SomeVarName.Length],
                             SomeVarName  = new martin.MyEnum[source.SomeVarName.Length]
                         };
            for (int i = 0; i < source.Items.Length; i++)
            {
                retVal.SomeVarName[i] = (martin.MyEnum)Enum.Parse(typeof(martin.MyEnum), source.SomeVarName[i].ToString());
                switch (source.ItemsElementName[i])
                {
                    //map any custom types
                    default:
                        retVal.SomeValueVar[i] = source.SomeValueVar[i]
                }
            }
            return retVal;
        }
    }
