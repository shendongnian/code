    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class ProgramInputs
        {
            public double LoanPayment;
            public double Insurance;
            public double Gas;
            public double Oil;
            public double Tires;
            public double Maintenance;
        }
    
        class ProgramOutputs
        {
            public double MonthlyTotal;
            public double AnnualTotal;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Please enter the following expenses on a per month basis");
    
                ProgramInputs inputs = getInputs();
                ProgramOutputs outputs = calculate(inputs);
    
                Console.WriteLine("Your monthly total is ${0:F2} and your annual total is ${1:F2}", outputs.MonthlyTotal, outputs.AnnualTotal);
            }
    
            static ProgramInputs getInputs()
            {
                // make a new program input object
                ProgramInputs inputs = new ProgramInputs();
    
                // get each input using a convenient method that factors out the parsing logic
                inputs.LoanPayment = getSingleInput("How much is the loan payment?");
                inputs.Insurance = getSingleInput("How much is the insurance?");
                inputs.Gas = getSingleInput("How much is the gas?");
                inputs.Oil = getSingleInput("How much is the oil?");
                inputs.Tires = getSingleInput("How much are the tires?");
                inputs.Maintenance = getSingleInput("How much is the maintenance?");
                
                // return them in single object, it's neater this way
                return inputs;
            }
    
            static double getSingleInput(string message)
            {
                double input = 0;
                Console.WriteLine(message);
                while (!double.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Error, enter a number");
                }
                return input;
            }
            
            static ProgramOutputs calculate(ProgramInputs inputs)
            {
                ProgramOutputs outputs = new ProgramOutputs();
                outputs.MonthlyTotal = inputs.LoanPayment + inputs.Insurance + inputs.Gas + inputs.Oil + inputs.Tires + inputs.Maintenance;
                outputs.AnnualTotal = outputs.MonthlyTotal * 12;
    
                return outputs;
            }
        }
    }
