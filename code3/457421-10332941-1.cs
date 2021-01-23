            /// <summary>
            /// If downloading, cancels a download in progress.
            /// </summary>
            public virtual void Cancel()
            {
                if (this.client != null)
                {
                    this.client.CancelAsync();
                }
            }
