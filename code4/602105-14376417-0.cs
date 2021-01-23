    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("$type");
        writer.WriteValue(RemoveAssemblyDetails(value.GetType().AssemblyQualifiedName.ToString()));
        writer.WriteEndObject();
    }
    private static string RemoveAssemblyDetails(string fullyQualifiedTypeName)
    {
        StringBuilder builder = new StringBuilder();
        // loop through the type name and filter out qualified assembly details from nested type names
        bool writingAssemblyName = false;
        bool skippingAssemblyDetails = false;
        for (int i = 0; i < fullyQualifiedTypeName.Length; i++)
        {
            char current = fullyQualifiedTypeName[i];
            switch (current)
            {
                case '[':
                    writingAssemblyName = false;
                    skippingAssemblyDetails = false;
                    builder.Append(current);
                    break;
                case ']':
                    writingAssemblyName = false;
                    skippingAssemblyDetails = false;
                    builder.Append(current);
                    break;
                case ',':
                    if (!writingAssemblyName)
                    {
                        writingAssemblyName = true;
                        builder.Append(current);
                    }
                    else
                    {
                        skippingAssemblyDetails = true;
                    }
                    break;
                default:
                    if (!skippingAssemblyDetails)
                        builder.Append(current);
                    break;
            }
        }
        return builder.ToString();
    }
