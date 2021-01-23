        /// <summary>
        /// Generates JSON schema for a given C# class using Newtonsoft.Json.Schema library.
        /// </summary>
        /// <param name="myType">class type</param>
        /// <returns>a string containing JSON schema for a given class type</returns>
        internal static string GenerateSchemaForClass(Type myType)
        {
            JSchemaGenerator jsonSchemaGenerator = new JSchemaGenerator();
            JSchema schema = jsonSchemaGenerator.Generate(myType);
            schema.Title = myType.Name;
            return schema.ToString();
        }
