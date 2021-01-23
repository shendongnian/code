    private void HandleWpfCompositionTargetRendering(object sender, EventArgs e)
    {
        RenderingEventArgs rea = e as RenderingEventArgs;
        
        // It's possible for Rendering to call back twice in the same frame
        // so only render when we haven't already rendered in this frame.
        if (this.lastRenderTime == rea.RenderingTime)
            return;
        
        if (this.renderIsFinished)
        {
            // Lock();
            // SetBackBuffer(...);
            // AddDirtyRect(...);
            // Unlock();
            
            this.renderIsFinished = false;
            // Fire event to start new render
            // the event needs to set this.renderIsFinished = true when the render is done
            
            // Remember last render time
            this.lastRenderTime = rea.RenderingTime;
        }
    }
