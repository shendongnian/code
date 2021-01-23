    /// <summary>
    /// <para>Returns a readable name for this type.</para>
    /// <para>e.g. for type = typeof(IEnumerable&lt;IComparable&lt;int&gt;&gt;),</para>
    /// <para>type.FriendlyName() returns System.Collections.Generic.IEnumerable&lt;System.IComparable&lt;int&gt;&gt;</para>
    /// <para>type.Name returns IEnumerable`1</para>
    /// <para>type.FullName() returns System.Collections.Generic.IEnumerable`1[[System.IComparable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]</para>
    /// </summary>
    public static string FriendlyName(this Type type)
    {
        string result;
        using ( var codeDomProvider = CodeDomProvider.CreateProvider("C#") )
        {
            var typeReferenceExpression = new CodeTypeReferenceExpression(new CodeTypeReference(type));
            using ( var writer = new StringWriter() )
            {
                codeDomProvider.GenerateCodeFromExpression(typeReferenceExpression, writer, new CodeGeneratorOptions());
                result = writer.GetStringBuilder().ToString();
            }
        }
        return result;
    }
