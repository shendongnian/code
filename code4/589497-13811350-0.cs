    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace DTOs
    {
        [DataContract]
        public class CustomerDTO
        {
            [DataMember]
            public int customerID { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public string surname { get; set; }
            [DataMember]
            public string street { get; set; }
            [DataMember]
            public string post_code { get; set; }
            [DataMember]
            public string city { get; set; }
            [DataMember]
            public string country { get; set; }
            [DataMember]
            public string personal_code { get; set; }
            [DataMember]
            public string phone_number { get; set; }
            [DataMember]
            public string group_type { get; set; }
            [DataMember]
            public string employee { get; set; }
            public CustomerDTO(int _customerID, string _name, string _surname, string _street, string _post_code, string _city, string _country, string _personal_code, string _phone_number, string _group_type, string _employee)
            {
                this.customerID = _customerID;
                this.name = _name;
                this.surname = _surname;
                this.street = _street;
                this.post_code = _post_code;
                this.city = _city;
                this.country = _country;
                this.personal_code = _personal_code;
                this.phone_number = _phone_number;
                this.group_type = _group_type;
                this.employee = _employee;
            }
        }
    }
