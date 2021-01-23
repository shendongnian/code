    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class Foo
    {  
        [StringLength(256)]
        public ICollection<string> Bars { get; set; }
    }
