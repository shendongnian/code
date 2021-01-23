            static void Main(string[] args)
            {
                int Size_of_OneDimensional = 0;
                int Start_Index = 0;
                int row = 0;
                int column=0;
                
    
                Console.WriteLine("Enter The number of elements you want to add in 1-D Array : ");
                Size_of_OneDimensional = Convert.ToInt32(Console.ReadLine());
    
                int[] One_Dimensional = new int[Size_of_OneDimensional];
    
                    for (int i = 0; i < Size_of_OneDimensional; i++)
                        {
                            Console.WriteLine("Enter "+i+" Element");
                            One_Dimensional[i] = Convert.ToInt32(Console.ReadLine());
                        }
    
                    Console.WriteLine("Emter Number of Row : ");
                    row = Convert.ToInt32(Console.ReadLine());
    
                    Console.WriteLine("Emter Number of Colum : ");
                    column= Convert.ToInt32(Console.ReadLine());
    
                    int[,] Two_Dimensional = new int[row, column];
    
                    Console.WriteLine("Here is your 2-D Array");
    
                    for (int i = 0; i < row; i++)
                        {
                        if (Start_Index == One_Dimensional.Length)
                            break;
                        for(int j = 0; j < column; j++)
                            {
                            Two_Dimensional[i, j] = One_Dimensional[Start_Index];
                            Start_Index++;     
                            Console.Write(Two_Dimensional[i, j]);
                            }
                            Console.WriteLine();
                        }
                    Console.ReadKey();
            }
        }
       }
