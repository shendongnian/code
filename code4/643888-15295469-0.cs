    public class modelData
    {
        public string CUSTOMERID { get; set; }
        public string NAME { get; set; }
        public string ADRESA { get; set; }
        public string ORDERID { get; set; }
        public string DATA { get; set; }
        public string VALOARE { get; set; }
        public string PRODUS { get; set; }
        public string VALOARE2 { get; set; }
        public string SERIAL { get; set; }
    };
    var results = (
        from a in db.CUSTOMERs
        join b in db.ORDERs on a.CUSTOMERID equals b.CUSTOMERID
        join c in db.ORDERDETAILS on b.ORDERID equals c.ORDERID
        select new modelData
        {
           CUSTOMERID = a.CUSTOMERID,
           NAME = a.NAME,
           ADRESA = a.ADRESA,
           ORDERID = b.ORDERID,
           DATA = b.DATA,
           VALOARE = b.VALOARE,
           PRODUS = c.PRODUS,
           VALOARE2 = c.VALOARE,
           SERIAL = c.SERIAL
        })
        .ToList();
