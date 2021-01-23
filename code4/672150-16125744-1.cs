    var qcs = Mapper.Map<Nullable<byte>, QualityControlState>(null); // OK
    qcs = Mapper.Map<Nullable<byte>, QualityControlState>(0);        // OK
    qcs = Mapper.Map<Nullable<byte>, QualityControlState>(1);        // Warning
    qcs = Mapper.Map<Nullable<byte>, QualityControlState>(2);        // Error
    qcs = Mapper.Map<Nullable<byte>, QualityControlState>(3);        // 3
