    scanner.Scan().ContinueWith((t) => RunOnUiThread(() =>
                        {
                            searchBar.Text = t.Result.Text;
                            var intent = new Intent(this, typeof(SearchResultsActivity));
                            intent.PutExtra("Description", searchBar.Text);
                            StartActivity(intent);
                        }));
