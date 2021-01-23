           public enum FixedWidthColumnType 
           {
                String,
                Num,
                Decimal 
           }
            [AttributeUsage()]
            public class FixedWidthColumn : Attribute  
            {      
                 public int Position { get; private set; }      
                 public int Length { get; private set; }        
                 public int Digits {get;set;}
                 public int FractionalDigits {get;set}
                 public FixedWidthColumnType Type {get; private set;}
                 public FixedWidthColumn(int position, int length, 
                       FixedWidthColumnType type)
      
                 {          this.Position = position;          
                            this.Length = length;      
                            this.Type = type;
                 }
             }  
             FixedColumnWidth(5, 6, FixedWidthColumnType.Decimal, Digits: 3, Precision : 4)
