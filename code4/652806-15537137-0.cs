    set PROD;     # products
    param T > 0;  # number of weeks
    param rate {PROD} > 0;          # tons per hour produced
    param inv0 {PROD} >= 0;         # initial inventory
    param avail {1..T} >= 0;        # hours available in week
    param market {PROD,1..T} >= 0;  # limit on tons sold in week
    param prodcost {PROD} >= 0;     # cost per ton produced
    param invcost {PROD} >= 0;      # carrying cost/ton of inventory
    param revenue {PROD,1..T} >= 0; # revenue per ton sold
    var Make {PROD,1..T} >= 0;      # tons produced
    var Inv {PROD,0..T} >= 0;       # tons inventoried
    var Sell {p in PROD, t in 1..T} >= 0, <= market[p,t]; # tons sold
    maximize Total_Profit:
      sum {p in PROD, t in 1..T} (revenue[p,t]*Sell[p,t] -
        prodcost[p]*Make[p,t] - invcost[p]*Inv[p,t]);
    subject to Time {t in 1..T}:
      sum {p in PROD} (1/rate[p]) * Make[p,t] <= avail[t];
    subject to Init_Inv {p in PROD}:  Inv[p,0] = inv0[p];
    subject to Balance {p in PROD, t in 1..T}:
      Make[p,t] + Inv[p,t-1] = Sell[p,t] + Inv[p,t];
        public class Steel {
           internal static int _nProd;
           internal static int _nTime;
           
           internal static double[] _avail;
           internal static double[] _rate;
           internal static double[] _inv0;
           internal static double[] _prodCost;
           internal static double[] _invCost;
           
           internal static double[][] _revenue;
           internal static double[][] _market;
           internal static void ReadData(string fileName) {
              InputDataReader reader = new InputDataReader(fileName);
              
              _avail    = reader.ReadDoubleArray();
              _rate     = reader.ReadDoubleArray();
              _inv0     = reader.ReadDoubleArray();
              _prodCost = reader.ReadDoubleArray();
              _invCost  = reader.ReadDoubleArray();
              _revenue  = reader.ReadDoubleArrayArray();
              _market   = reader.ReadDoubleArrayArray();
              
              _nProd = _rate.Length;
              _nTime = _avail.Length;
           }
           
           public static void Main(string[] args) {
              try {
                 string filename = "../../../../examples/data/steel.dat";
                 if ( args.Length > 0 )
                    filename = args[0];
                 ReadData(filename);
                 
                 Cplex cplex = new Cplex();
               
                 // VARIABLES
                 INumVar[][] Make = new INumVar[_nProd][];
                 for (int p = 0; p < _nProd; p++) {
                    Make[p] = cplex.NumVarArray(_nTime, 0.0, System.Double.MaxValue);
                 }
               
                 INumVar[][] Inv = new INumVar[_nProd][];
                 for (int p = 0; p < _nProd; p++) {
                    Inv[p] = cplex.NumVarArray(_nTime, 0.0, System.Double.MaxValue);
                 }
               
                 INumVar[][] Sell = new INumVar[_nProd][];
                 for (int p = 0; p < _nProd; p++) {
                     Sell[p] = new INumVar[_nTime];
                    for (int t = 0; t < _nTime; t++) {
                       Sell[p][t] = cplex.NumVar(0.0, _market[p][t]);
                    }
                 }
               
                 // OBJECTIVE
                 ILinearNumExpr TotalRevenue  = cplex.LinearNumExpr();
                 ILinearNumExpr TotalProdCost = cplex.LinearNumExpr();
                 ILinearNumExpr TotalInvCost  = cplex.LinearNumExpr();
                 
                 for (int p = 0; p < _nProd; p++) {
                    for (int t = 1; t < _nTime; t++) {
                       TotalRevenue.AddTerm (_revenue[p][t], Sell[p][t]);
                       TotalProdCost.AddTerm(_prodCost[p], Make[p][t]);
                       TotalInvCost.AddTerm (_invCost[p], Inv[p][t]);
                    }
                 }
                   
                 cplex.AddMaximize(cplex.Diff(TotalRevenue, 
                                              cplex.Sum(TotalProdCost, TotalInvCost)));
               
                 // TIME AVAILABILITY CONSTRAINTS
               
                 for (int t = 0; t < _nTime; t++) {
                    ILinearNumExpr availExpr = cplex.LinearNumExpr();
                    for (int p = 0; p < _nProd; p++) {
                       availExpr.AddTerm(1.0/_rate[p], Make[p][t]);
                    }
                    cplex.AddLe(availExpr, _avail[t]);
                 }
               
                 // MATERIAL BALANCE CONSTRAINTS
               
                 for (int p = 0; p < _nProd; p++) {
                    cplex.AddEq(cplex.Sum(Make[p][0], _inv0[p]), 
                                cplex.Sum(Sell[p][0], Inv[p][0]));
                    for (int t = 1; t < _nTime; t++) {
                       cplex.AddEq(cplex.Sum(Make[p][t], Inv[p][t-1]), 
                                   cplex.Sum(Sell[p][t], Inv[p][t]));
                    }
                 }
               
                 cplex.ExportModel("steel.lp");
               
                 if ( cplex.Solve() ) {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Total Profit = " + cplex.ObjValue);
                  
                    System.Console.WriteLine();
                    System.Console.WriteLine("\tp\tt\tMake\tInv\tSell");
                  
                    for (int p = 0; p < _nProd; p++) {
                       for (int t = 0; t < _nTime; t++) {
                          System.Console.WriteLine("\t" + p +"\t" + t +"\t" + cplex.GetValue(Make[p][t]) +
                                                   "\t" + cplex.GetValue(Inv[p][t]) +"\t" + cplex.GetValue(Sell[p][t]));
                       }
                    }
                 }
                 cplex.End();
              }
              catch (ILOG.Concert.Exception exc) {
                 System.Console.WriteLine("Concert exception '" + exc + "' caught");
              }
              catch (System.IO.IOException exc) {
                 System.Console.WriteLine("Error reading file " + args[0] + ": " + exc);
              }
              catch (InputDataReader.InputDataReaderException exc) {
                 System.Console.WriteLine(exc);
              }
           }
        }
