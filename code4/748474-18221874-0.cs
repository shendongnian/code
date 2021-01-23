    using System;
    using System.Collections.Generic;
    using ProjectII.Models.domain;
    namespace ProjectII.Viewmodels
    {
    public class DataModel
    {
        public List<DatumModel> Datums { get; set; }
        public List<ToekomstModel> Toekomst{ get; set; }
    }
    public class DatumModel
    {
        public DatumModel()
        {
            Dag = new Opleidingdag(new DateTime().Date);
            Checked = true;
        }
        public DatumModel(Opleidingdag opldag)
        {
            Dag = opldag;
            Checked = true;
        }
        public Opleidingdag Dag { get; set; }
        public bool Checked { get; set; }
    }
    public class ToekomstModel
    {
        public ToekomstModel()
        {
            Dag = new Opleidingdag(new DateTime().Date);
        }
        public ToekomstModel(Opleidingdag opldag)
        {
            Dag = opldag;
        }
        public Opleidingdag Dag { get; set; }
    }
    }
