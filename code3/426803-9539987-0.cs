    using System;
    using System.Drawing;
    using System.Collections;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using System.ComponentModel.Design;
    using CustomTabControlExample.TabControl;
    
    namespace CustomTabControlExample.Design {
        public class CustomTabControlDesigner :ParentControlDesigner {
            DesignerVerbCollection fVerbs;
            public override DesignerVerbCollection Verbs {
                get {
                    if (fVerbs == null)
                        fVerbs = new DesignerVerbCollection(new DesignerVerb[] {
                            new DesignerVerb("Add Tab", OnAdd)
                            });
                    return fVerbs;
                }
            }
    
            void OnAdd(object sender, EventArgs e) {
                TabPage newPage = (TabPage)((IDesignerHost)GetService(typeof(IDesignerHost))).CreateComponent(
                    typeof(CustomTabPage));
                newPage.Text = newPage.Name;
                ((System.Windows.Forms.TabControl)Component).TabPages.Add(newPage);
            }
    
            public override void InitializeNewComponent(IDictionary defaultValues) {
                base.InitializeNewComponent(defaultValues);
                for (int i = 0; i < 2; i++)
                    OnAdd(this, EventArgs.Empty);
            }
    
            protected override void WndProc(ref Message m) {
                base.WndProc(ref m);
                // Selection of tabs via mouse
                if (m.Msg == 0x201/*WM_LBUTTONDOWN*/) {
                    System.Windows.Forms.TabControl control = (System.Windows.Forms.TabControl)Component;
                    int lParam = m.LParam.ToInt32();
                    Point hitPoint = new Point(lParam & 0xffff, lParam >> 0x10);
                    if (Control.FromHandle(m.HWnd) == null) // Navigation
                        if (hitPoint.X < 18 && control.SelectedIndex > 0) // Left
                            control.SelectedIndex--;
                        else control.SelectedIndex++; // Right
                    else // Header click
                        for (int i = 0; i < control.TabCount; i++)
                            if (control.GetTabRect(i).Contains(hitPoint)) {
                                control.SelectedIndex = i;
                                return;
                            }
                }
            }
    
            protected override void OnDragDrop(DragEventArgs de) {
                ((IDropTarget)((System.Windows.Forms.TabControl)Component).SelectedTab).OnDragDrop(de);
            }
    
            protected override void OnDragEnter(DragEventArgs de) {
                ((IDropTarget)((System.Windows.Forms.TabControl)Component).SelectedTab).OnDragEnter(de);
            }
    
            protected override void OnDragLeave(EventArgs e) {
                ((IDropTarget)((System.Windows.Forms.TabControl)Component).SelectedTab).OnDragLeave(e);
            }
    
            protected override void OnDragOver(DragEventArgs de) {
                ((IDropTarget)((System.Windows.Forms.TabControl)Component).SelectedTab).OnDragOver(de);
            }
        }
    }
