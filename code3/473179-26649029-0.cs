    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    
    namespace System.Windows.Forms {
    	public class RegexTextBox : TextBox {
    		[Category("Behavior")]
    		public string RegexPattern { get; set; }
    		private bool DelOrBack = false;
    		protected override void OnKeyDown(KeyEventArgs e) {
    			base.OnKeyDown(e);
    			if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) {
    				DelOrBack = true;
    			}
    		}
    
    		protected override void OnKeyPress(KeyPressEventArgs e) {
    			if (!Regex.IsMatch(this.Text + e.KeyChar, RegexPattern) && !DelOrBack) {
    				e.Handled = true;				
    			}
    			else {
    				base.OnKeyPress(e);
    			}
    
    			DelOrBack = false;
    		}
    	}
    
    	public class NumericTextBox : RegexTextBox {
    		public NumericTextBox() {
    			RegexPattern = "^[0-9]+$";
    		}
    	}
    }
