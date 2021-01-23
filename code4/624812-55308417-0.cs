    public class TheDataModel 
    {
           [System.ComponentModel.Browsable(false)]
           public virtual int ID { get; protected set; }
           public virtual string FileName { get; set; }
           [System.ComponentModel.Browsable(false)]
           public virtual string ColumnNotShown1 { get; set; }
           [System.ComponentModel.Browsable(false)]
           public virtual string ColumnNotShown2  { get; set; }
    }
