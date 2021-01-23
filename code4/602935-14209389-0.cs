    using System.ComponentModel.DataAnnotations;
    public class AccountCreateViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        /* ... */
    }
