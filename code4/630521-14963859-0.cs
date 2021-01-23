    [DataContract]
    public class Model2
    {
        private string status;
        private string name;
        private string telephone;
        public Model2(){}
        public Model2(string sStatus, string sName, string sTelephone)
        {
            Status = sStatus;
            Name = sName;
            Telephone = sTelephone;
        }
        ...etc
