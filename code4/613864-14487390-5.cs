    public static class FormExtensions
    {
        public static Task WhenClosed(this Form form)
        {
            var tcs = new TaskCompletionSource<bool>();
            form.FormClosed += (sender, args) => tcs.SetResult(true);
            return tcs.Task;
        }
    }
