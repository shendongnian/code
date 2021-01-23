    public static string ATexto<T>(this T enumeración) where T : struct, Enum {
        var tipo = enumeración.GetType();
        return tipo.GetMember(enumeración.ToString())
        .Where(x => x.MemberType == MemberTypes.Field && ((FieldInfo)x).FieldType == tipo).First()
        .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumeración.ToString();
    } 
