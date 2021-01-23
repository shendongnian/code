    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;    // Add reference to System.Design
    
    [Designer(typeof(ParentControlDesigner))]
    class PictureContainer : PictureBox {}
