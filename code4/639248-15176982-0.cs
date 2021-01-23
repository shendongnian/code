        <Grid x:Name="gr01"...
You can write a function for attaching the events and call that in the Window_Loaded event.
    namespace AttachEventDemo {
       public partial class MainWindow : Window {
          // ... usual initialization code goes here
          private void Window_Loaded( object sender, RoutedEventArgs e ) {
             AttachEvent( );
          }
          private void AttachEvent( ) {
             foreach ( var item in gr01.Children ) {
                switch ( item.GetType( ).ToString( ) ) {
                   case "System.Windows.Forms.Button":
                      Button b = item as Button;
                      b.Click += b_Click;
                      txtLog.Text = "Added click event for button " + b.Name + Environment.NewLine + txtLog.Text;
                      break;
    
                   case "System.Windows.Forms.CheckBox":
                      CheckBox cb = item as CheckBox;
                      cb.Checked += cb_Checked;
                      txtLog.Text = "Added click event for checkkbox " + cb.Name + Environment.NewLine + txtLog.Text;
                      break;
    
                   default:
                      break;
                }
             }
          }
    
          void cb_Checked( object sender, RoutedEventArgs e ) {
             CheckBox cb = sender as CheckBox;
             txtLog.Text = "CheckBox " + cb.Name + " checked changed!" + Environment.NewLine + txtLog.Text;
          }
    
          private void b_Click( object sender, RoutedEventArgs e ) {
             Button b = sender as Button;
    
             txtLog.Text = "Button " + b.Name + " was clicked!" + Environment.NewLine + txtLog.Text;
          }
       }
    }
