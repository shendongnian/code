    using System;
    using Microsoft.SolverFoundation.Services;
    
    namespace akMSFStackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                Double[,] y = 
                {
                    { 5, 1, 0 },
                    { 1, 9, 1 },
                    { 0, 1, 9 },
                };
    
                Term goal;
                Term[,] tx;
                Term[,] ty;
    
                SolverContext context = SolverContext.GetContext();             // Get context environment
                Model model = context.CreateModel();                            // Create a new model
    
                Decision d1 = new Decision(Domain.RealNonnegative, "d1");       // First item in "x" vector (must be >= 0)
                Decision d2 = new Decision(Domain.RealNonnegative, "d2");       // Second item in "x" vector (must be >= 0)
                Decision d3 = new Decision(Domain.RealNonnegative, "d3");       // Third item in "x" vector (must be >= 0)
                model.AddDecisions(d1, d2, d3);                                 // Add these to the model (this is where the outputs will be stored)
    
                model.AddConstraints("limits",                                  // Add constraints
                    0 <= d1 <= 1,                                               // Each item must be between 0 and 1
                    0 <= d2 <= 1,
                    0 <= d3 <= 1,
                    d1 + d2 + d3 == 1);                                         // All items must add up to 1
    
                ty = matrix(y);
                tx = new Term[,] { { d1, d2, d3 } };
    
                goal = matMult(matMult(tx, ty), transpose(tx))[0, 0];
    
                model.AddGoal("goal", GoalKind.Minimize, goal);
    
                // Specifying the IPM solver, as we have a quadratic goal 
                Solution solution = context.Solve(new InteriorPointMethodDirective());
    
    
                Report report = solution.GetReport();
                Console.WriteLine("x {{{0}, {1}, {2}}}", d1, d2, d3);
                Console.Write("{0}", report); 
       
            }
    
    
            static Term[,] matrix(Double[,] m)
            {
                int rows = m.GetLength(0);
                int cols = m.GetLength(1);
                Term[,] r = new Term[rows, cols];
    
                for (int row = 0; row < rows; row++)
                    for (int col = 0; col < cols; col++)
                        r[row, col] = m[row, col];
    
                return r;
            }
    
            static Term[,] matMult(Term[,] a, Term[,] b)
            {
                int rows = a.GetLength(0);
                int cols = b.GetLength(1);
                Term[,] r = new Term[rows, cols];
    
                for (int row = 0; row < rows; row++)
                    for (int col = 0; col < cols; col++)
                    {
                        r[row,col] = 0;
                        for (int k = 0; k < a.GetLength(1); k++)
                        {
                            r[row, col] += a[row, k] * b[k, col];
                        }
                    }
    
                return r;
            }
    
            static Term[,] transpose(Term[,] m)
            {
                int rows = m.GetLength(0);
                int cols = m.GetLength(1);
                Term[,] r = new Term[cols, rows];
    
                for (int row = 0; row < rows; row++)
                    for (int col = 0; col < cols; col++)
                    {
                        r[col, row] = m[row, col];
                    }
    
                return r;
            }
        }
    }
