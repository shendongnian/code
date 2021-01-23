        [WebMethod]
        public static string CallAJAX(string Iwant)
        {
            if (string.IsNullOrEmpty(Iwant)) throw new Exception("What You want ?");
            return "One " + Iwant + " for You";
        }
