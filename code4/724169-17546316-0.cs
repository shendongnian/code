    using System.Reflection;
    ...
        private static bool IsAnimating(PictureBox box) {
            var fi = box.GetType().GetField("currentlyAnimating",
                BindingFlags.NonPublic | BindingFlags.Instance);
            return (bool)fi.GetValue(box);
        }
        private static void Animate(PictureBox box, bool enable) {
            var anim = box.GetType().GetMethod("Animate", 
                BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(bool) }, null);
            anim.Invoke(box, new object[] { enable });
        }
