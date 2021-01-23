    BaseDataPoint
        {
            public double A;
            public double B;
            public BaseDataPoint(double A, double B)
            {
                this.A = A;
                this.B = B;
            }
        }
    
        class ReportDataPoint : BaseDataPoint
         {
            static const double defaultCValue = 0.0;
            public double C;
            public ReportDataPoint(double A, double B, double C)
             :base(A,B){
                this.C = C;
              }
           public ReportDataPoint(BaseDataPoint p,double C=defaultCValue) :
            this(p.A, p.B, C)
           { }
        }
        ...
        BaseDataPoint p1=new BaseDataPoint(1,2);
        ReportDataPoint p2=new ReportDataPoint(p1);
