    var r = (IObjectMapper[])typeof(MappingEngine).GetField("_mappers", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(((MappingEngine)(AutoMapper.Mapper.Engine)));
    Array.Resize(ref r, r.Length + 1);
    Array.Copy(r, 0, r, 1, r.Length - 1);
    r[0] = new NullableMapper();
    typeof(MappingEngine).GetField("_mappers", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(((MappingEngine)(AutoMapper.Mapper.Engine)), r);
