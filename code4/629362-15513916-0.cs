    using System.Windows.Controls;
    using System.Windows;
    using System.Windows.Data;
    namespace Utils {
    	class ComboBoxWin8 : ComboBox {
    		public ComboBoxWin8() {
    			Loaded += ComboBoxWin8_Loaded;
    		}
    		void ComboBoxWin8_Loaded(object sender, RoutedEventArgs e) {
    			ControlTemplate ct = Template;
    			Border border = ct.FindName("Border", this) as Border;
    
    			// if Windows8
    			if (border != null) {
    				border.Background = Background;
    
    				// In the case of bound property
    				BindingExpression be = GetBindingExpression(ComboBoxWin8.BackgroundProperty);
    				if (be != null) {
    					border.SetBinding(Border.BackgroundProperty, be.ParentBindingBase);
    				}
    			}
    		}
    	}
    }
