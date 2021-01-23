    public void CurrentPath(string url)
        {
            // Push the current page on to the navigation stack
            if (PageStack == null)
            {
                PageStack = new Stack<PreviousPath>();
            }
            var pageFrame = new PageFrame { Path = url };
            PageStack.Push(pageFrame);
            }
        }
