    void DoPrint()
    {
        MyPrintDocument mydoc = new MyPrintDocument();
        PrinterSettings ps = ShowPrintDialog();
        if (ps != null)
        {
            ps.Duplex = Duplex.Simplex; // This works
            mydoc.PrinterSettings = ps;
            StandardPrintController cont = new StandardPrintController();
            mydoc.PrintController = cont;
            mydoc.Print();
        }
    }
