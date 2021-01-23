    <pre><code>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Excel = Microsoft.Office.Interop.Excel;
    using Office = Microsoft.Office.Core;
    using Microsoft.Office.Tools.Excel;
    using System.Diagnostics;
    using Microsoft.Office.Interop.Excel;
    
    namespace Excel_Menu
    {
        public partial class ThisAddIn
        {
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                ResetCellMenu();  // reset the cell context menu back to the default
                
                // Call this function is the user right clicks on a cell
                this.Application.SheetBeforeRightClick+=new Excel.AppEvents_SheetBeforeRightClickEventHandler(Application_SheetBeforeRightClick);
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
            
            private Office.CommandBar GetCellContextMenu()
            {
                return this.Application.CommandBars["Cell"];
            }
            
            private void ResetCellMenu()
            {
                GetCellContextMenu().Reset(); // reset the cell context menu back to the default
            }
    
            private void Application_SheetBeforeRightClick(object Sh, Range Target, ref bool Cancel)
            {
                ResetCellMenu();  // reset the cell context menu back to the default
    
                if (Target.Cells.Count == 1)   // sample code: if only a single cell is selected
                {
                    if (Target.Cells[1, 1].Value == "abc") // sample code: if the signle cell contains 'abc'
                    {
                        AddExampleMenuItem();
                        RemoveCutCopyPasteMenuItems();
                    }
                }
            }
    
            private void AddExampleMenuItem()
            {
                Office.MsoControlType menuItem = Office.MsoControlType.msoControlButton;
                Office.CommandBarButton exampleMenuItem = (Office.CommandBarButton)GetCellContextMenu().Controls.Add(menuItem, missing, missing, 1, true);
    
                exampleMenuItem.Style = Office.MsoButtonStyle.msoButtonCaption;
                exampleMenuItem.Caption = "Example Menu Item";
                exampleMenuItem.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(exampleMenuItemClick);
            }
    
            private void RemoveCutCopyPasteMenuItems()
            {
                Office.CommandBar contextMenu = GetCellContextMenu();
    
                for (int i = contextMenu.Controls.Count; i > 0; i--)
                {
                    Office.CommandBarControl control = contextMenu.Controls[i];
    
                    if (control.Caption == "Cu&t") control.Delete();  // Sample code: remove cut menu item
                    else if (control.Caption == "&Copy") control.Delete();  // Sample code: remove copy menu item
                    else if (control.accDescription.Contains("Paste")) control.Delete(); // Sample code: remove any paste menu items
                }
            }
    
            void exampleMenuItemClick(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
            {
                System.Windows.Forms.MessageBox.Show("Example Menu Item clicked");
            }
    
            #region VSTO generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InternalStartup()
            {
                this.Startup += new System.EventHandler(ThisAddIn_Startup);
                this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            }
            
            #endregion
        }
    }
    
    </code></pre>
