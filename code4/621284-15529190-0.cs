    using System;
    using Gtk;
    
    
        namespace WaitingTest
        {
            public class MainClass
            {       
                static void Main (string[] args)
                {
                    Application.Init ();
                    new MenuWindow();
                    Application.Run();
                }
            }
            public class MenuWindow
            {
                public static string favDrink = "Water";
                public static string favCheese = "Chedder";
                public static Label output = new Label();
        
                public MenuWindow()
                {
                    Application.Init ();
        
                    Window test = new Window ("Main Window");
        
                    VBox vb = new VBox();
                    Button getData = new Button("Get Data");
                    Button quitApp = new Button("Quit");
        
                    getData.Clicked += OnGetData;
                    quitApp.Clicked += OnExit;
        
                    vb.PackStart(getData, false, false, 1);
                    vb.PackStart(quitApp, false, false, 1);
                    vb.PackStart(output, false, false, 1);
        
                    test.Add(vb);
                    test.ShowAll();
        
                    Application.Run();
                }
        
                static void OnGetData(object sender, EventArgs args)
                {
                    // Open up Window to select drink
                    new WindowOne();
                }
        
                public static void SetFavDrink(string d)
                {
                    MenuWindow.favDrink = d;
                    Console.WriteLine(favDrink);
                }
        
                public static void SetFavCheese(string c)
                {
                    MenuWindow.favCheese = c;
                    Console.WriteLine(favCheese);
                }
        
                static void OnExit(object sender, EventArgs args)
                {
                    Application.Quit();
                }
        
                protected void OnDeleteEvent(object sender, DeleteEventArgs a)
                {
                    Application.Quit ();
                    a.RetVal = true;
                }   
            }
        
            class WindowOne
            {
                ComboBox drink = ComboBox.NewText();
                static string choice;
        		static Window w1 = new Window ("Window One");
                public WindowOne ()
                {
                   
        
                    VBox vb = new VBox();
        
                    Button sendDrink = new Button("Send Drink");
        
                    sendDrink.Clicked += OnSend;
                    drink.Changed += new EventHandler(onDrinkChanged);
        
                    drink.AppendText("Beer");
                    drink.AppendText("Red Wine");
                    drink.AppendText("White Wine");
                    drink.AppendText("Whiskey");
        
                    vb.PackStart(drink, false, false, 1);
                    vb.PackStart(sendDrink, false, false, 1);
        
                    w1.Add(vb);
                    w1.ShowAll();
                }
        
                void OnSend(object sender, EventArgs args)
                {
                    WaitingTest.MenuWindow.SetFavDrink(choice);
        			WindowOne.w1.Destroy();
        			new WindowTwo();
        
                }
        
                void onDrinkChanged(object o, EventArgs args)
                {
                    ComboBox combo = o as ComboBox;
                    if (o == null)
                        return;
        
                    TreeIter iter;
        
                    if (combo.GetActiveIter (out iter))
                        choice = ((string) combo.Model.GetValue (iter, 0));
                }
            }
        
            class WindowTwo
            {
                ComboBox cheese = ComboBox.NewText();
                static string choice;
         		static Window w2 = new Window ("Window Two");
                public WindowTwo ()
                {
                  
        
                    VBox vb = new VBox();
        
                    Button sendCheese = new Button("Send Cheese");
        
                    sendCheese.Clicked += OnSend;
                    cheese.Changed += new EventHandler(onCheeseChanged);
        
                    cheese.AppendText("Gorgonzola");
                    cheese.AppendText("Edam");
                    cheese.AppendText("Brie");
                    cheese.AppendText("Feta");
        
                    vb.PackStart(cheese, false, false, 1);
                    vb.PackStart(sendCheese, false, false, 1);
        
                    w2.Add(vb);
                    w2.ShowAll();
                }
        
                void OnSend(object sender, EventArgs args)
                {
                    WaitingTest.MenuWindow.SetFavCheese(choice);
        			WindowTwo.w2.Destroy();
        			MenuWindow.output.Text="Drink: "+MenuWindow.favDrink+"\nCheese: "+MenuWindow.favCheese;
                }
        
                void onCheeseChanged(object o, EventArgs args)
                {
                    ComboBox combo = o as ComboBox;
                    if (o == null)
                        return;
        
                    TreeIter iter;
        
                    if (combo.GetActiveIter (out iter))
                        choice = ((string) combo.Model.GetValue (iter, 0));
                }
            }
        }
    
    `
