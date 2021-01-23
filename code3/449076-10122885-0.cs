    using System;
    using System.Data;
    using Microsoft.SqlServer.Server;
    using System.Data.SqlTypes;
    using System.IO;
    using System.Text;
    
    [Serializable]
    [SqlUserDefinedAggregate(
        Format.UserDefined, //use clr serialization to serialize the intermediate result
        IsInvariantToNulls = true, //optimizer property
        IsInvariantToDuplicates = false, //optimizer property
        IsInvariantToOrder = false, //optimizer property
        MaxByteSize = 8000) //maximum size in bytes of persisted value
    ]
    
    public class GetFirst : IBinarySerialize
    {
        private int Value;
        private int OrderBy;
    
    [SqlFunctionAttribute(IsDeterministic = true)]
        public void Init()
        {
          Value = 0;
          OrderBy = int.MaxValue;
        }
    
    [SqlFunctionAttribute(IsDeterministic = true)]
        public void Accumulate(SqlInt32 SValue, SqlInt32 SOrderBy)
        {
            if (SValue.IsNull)
            {
                return;
            }
    
            if (SOrderBy.IsNull)
            {
                return;
            }
    
            if (SOrderBy.Value < OrderBy)
            {
                Value = SValue.Value;
                OrderBy = SOrderBy.Value;
            }
        }
    
    [SqlFunctionAttribute(IsDeterministic = true)]
        public void Merge(GetFirst other)
        {
            if (other.OrderBy < OrderBy)
            {
                Value = other.Value;
                OrderBy = other.OrderBy;
            }
        }
    
    [SqlFunctionAttribute(IsDeterministic = true)]
        public SqlInt32 Terminate()
        {
          return new SqlInt32(Value);
        }
    
    [SqlFunctionAttribute(IsDeterministic = true)]
        public void Read(BinaryReader r)
        {
            Value = r.ReadInt32();
            OrderBy = r.ReadInt32();
        }
    
    [SqlFunctionAttribute(IsDeterministic = true)]
        public void Write(BinaryWriter w)
        {
            w.Write(Value);
            w.Write(OrderBy);
        }
    }
