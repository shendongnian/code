    using System;
    namespace NorwayTax
    {
      public class NorwayTaxFiles
      {
        [Serializable]
        public class NorwayFile
        {
          public string FileName { set; get; }
          public byte[] Data { set; get; }
        }
      }
    }
