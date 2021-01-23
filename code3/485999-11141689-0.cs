        using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace ConsoleApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        //main logic of switching language of UI
        void ChangeCulture_Handler(CultureInfo culture)
        {
            //getting relative path of resource file for specific culture
            var resourcePath = GetLocalizedResourceFile(culture);
            //initialize new reader of resource file
            var reader = new ResXResourceReader(resourcePath);
            //getting enumerator
            var resourceEnumerator = reader.GetEnumerator();
            //enumerate each record in resource file
            while (resourceEnumerator.MoveNext())
            {
                string resKey = Convert.ToString(resourceEnumerator.Key);
                //we can add here some check if need 
                //(for example if in resource file exists not only controls resources with format <Control Name>.<Property>
                //if( resKey.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Length == 2) 
                string resValue = Convert.ToString(resourceEnumerator.Value);
                //actually update property
                UpdateControl(resKey, resValue);
            }
        }
        //main logic of updating property of one control
        private void UpdateControl(string resKey, string resValue)
        {
            //we suppose that format of keys in resource file is <Control Name>.<Property>
            var strs = resKey.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var controlName = strs[0];
            var controlProp = strs[1];
            //find control of form by its name
            var controls = this.Controls.Find(controlName, true);
            if (controls.Length > 0)
            {
                //select first control
                var control = controls[0];
                //getting type of it
                var t = control.GetType();
                //getting property
                var props = t.GetProperty(controlProp);
                if (props != null)
                {
                    //setting localized value to property
                    props.SetValue(control, resValue, null);
                }
            }
        }
        //build resource file path
        string GetLocalizedResourceFile(CultureInfo ci)
        {
            string cultureCode = ci.TwoLetterISOLanguageName;
            //for english language is default, so we don't have a need to add "en" part in path 
            return cultureCode != "en" ? string.Format("Resource1.{0}.resx", cultureCode) : "Resource1.resx";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            ChangeCulture_Handler(Thread.CurrentThread.CurrentCulture);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            ChangeCulture_Handler(Thread.CurrentThread.CurrentCulture);
        }
    }
