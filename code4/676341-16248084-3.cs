        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.ComponentModel;
    
    namespace ClassLibrary1
    {
        public class MyButton : System.Web.UI.WebControls.Button
        {
    
            [DefaultValue(typeof(Color), "")]
            public virtual Color BackColor
            {
                get
                {
                    if (!this.ControlStyleCreated)
                        return Color.Empty;
                    else
                        return this.ControlStyle.BackColor;
                }
                private set
                {
                   // this.ControlStyle.BackColor = value;  , OVerride it with your  MyColor
                    this.ControlStyle.BackColor =YourMethodConvertMyColorToColor(this.BackColor2);
                }
            }
    
            private Color YourMethodConvertMyColorToColor(MyColor c){
                //your implementation 
                if (c == MyColor.MyColorGreen)
                {
                    return ColorTranslator.FromHtml("#FF0000"); ; //just example
                }
    
                return Color.Green;//default
            }
    
            MyColor _mycolor;  //Global Value
         
            [DefaultValue(typeof(MyColor), "")]
            public  MyColor BackColor2
            {
                get
                {
                    return _mycolor;
                }
                set
                {
                    this._mycolor = value;
                }
            }
        }
    
        public enum MyColor
        {
           MyColorGreen=1,
           MyColorBlue=2
        }
    }
