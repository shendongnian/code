    using System;
    using MonoTouch.UIKit;
    namespace PythonMath
    {
        class SplitViewControllerDelegate : UISplitViewControllerDelegate
        {
            public override bool ShouldHideViewController(
                UISplitViewController svc,
                UIViewController viewController,
                UIInterfaceOrientation inOrientation)
            {
                return (! InAppPurchaseModel.Editor.Purchased) ||
                    inOrientation == UIInterfaceOrientation.Portrait ||
                    inOrientation == UIInterfaceOrientation.PortraitUpsideDown;
            }
        }
    }
