        protected void InvalidateSpans(IList<SnapshotSpan> spans)
        {
            if (spans.Count == 0)
                return;
            bool wasEmpty = false;
            lock (this.invalidatedSpans)
            {
                wasEmpty = this.invalidatedSpans.Count == 0;
                this.invalidatedSpans.AddRange(spans);
            }
            if (wasEmpty)
                this.view.VisualElement.Dispatcher.BeginInvoke(new Action(AsyncUpdate));
        }
