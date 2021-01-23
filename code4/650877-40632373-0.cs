    using System;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    
    namespace CUIT
    {
        [CodedUITest]
        public class UITestDemo
        {
            private readonly string path = @"C:\Windows\SysWOW64\calc.exe";
            static ApplicationUnderTest app = null;
    
            [TestMethod]
            public void Start()
            {
                app = ApplicationUnderTest.Launch(path);
                Playback.Wait(1000);
                app.CloseOnPlaybackCleanup = false;
                app.SearchProperties[ApplicationUnderTest.PropertyNames.Name] = "Calculator";
                app.SearchProperties[ApplicationUnderTest.PropertyNames.ClassName] = "CalcFrame";
            }
    
            [TestMethod]
            public void TestButtonOne()
            {
                Assert.IsNotNull(app, "Should not be NULL!");
                app.SetFocus();
                WinButton btn1 = new WinButton(app);
                btn1.SearchProperties[WinButton.PropertyNames.Name] = "1";
                Mouse.Click(btn1);
                Mouse.Click(btn1);
                Mouse.Click(btn1);
                Playback.Wait(3000);
            }
        }
    }
