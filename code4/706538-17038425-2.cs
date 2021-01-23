    namespace EntityFrameworkByteToLong.Models
    {
        public class SomeEntity
        {
            public int Id { get; set; }
    
            public byte[] SomeBytes { get; set; } //this is the column in your DB that can't be changed
    
            [NotMapped]
            public long SomeByteWrapper //your wrapper obviously
            {
                get
                {
                    return BitConverter.ToInt64(SomeBytes, 0);
                }
                set
                {
                    SomeBytes = BitConverter.GetBytes(value);
                }
            }
        }
    }
