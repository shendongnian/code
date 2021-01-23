            if (request.Content != null)
            {
                request.Content.ReadAsByteArrayAsync().ContinueWith
                    (
                        (task) =>
                        {
                            
                                var xxx = System.Text.UTF8Encoding.UTF8.GetString(task.Result);
                        });
            }
            return base.SendAsync(request, cancellationToken) //than call the base
.
.
.
