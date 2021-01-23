    using System.Collections.Generic;
    using System.Windows;
    using System.ComponentModel;
    
    namespace WpfApplication4
    {
        public partial class Window17 : Window
        {
            public Window17()
            {
               InitializeComponent();
               var random = new Random();
               var board = new List<SudokuViewModel>();
               for (int i = 0; i < 9; i++)
               {
                   for (int j = 0; j < 9; j++)
                   {
                       board.Add(new SudokuViewModel() {Row = i, Column = j,Value = random.Next(1,20)});
                   }
               }
               DataContext = board;            
           }
       }
    }
