                var continuation = Task.Factory.ContinueWhenAll(
                            tasks,
                            (antecedents) =>
                            {
                                //Do Some Work Here
                            });
                continuation.Wait();
