    class Karakter
    {
        public string Isim { get; set; }
        public float Can { get; set; }
        public int Seviye { get; set; }
        public int Exp { get; set; }
        public float Guc { get; set; }
        public string Irk { get; set; }
        public int vExp { get; set; }
        public override string ToString()
        {
            return String.Format("Adınız:{0}\nIrkınız:{1}\nCan:{2}\nGuc:{3}\nExp:{4}\nSeviye:{5}", 
                                 Isim, Irk, Can, Guc, Exp, Seviye);
        }
    }
