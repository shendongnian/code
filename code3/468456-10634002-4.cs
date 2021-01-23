    long? variable1 = reader.IsDBNull(2) ? default : reader.GetInt64(2); // requires C# 7.1
    long? variable1 = reader.IsDBNull(2) ? default(long?) : reader.GetInt64(2);
    long? variable1 = reader.IsDBNull(2) ? (long?)null : reader.GetInt64(2);
    long? variable1 = reader.IsDBNull(2) ? new Nullable<long>() : reader.GetInt64(2);
    long? variable1 = reader.IsDBNull(2) ? new long?() : reader.GetInt64(2);
    long? variable1 = reader.IsDBNull(2) ? null : new long?(reader.GetInt64(2));
