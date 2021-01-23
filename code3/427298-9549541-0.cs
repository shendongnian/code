    void ShaderChanged(object sender, FileSystemEventArgs e)
    {
        _shaderFileWatcher.EnableRaisingEvents = false; // prevent more/duplicate events from firing before we've finished processing the current one
        lock (_renderQueue)
        {
            _renderQueue.Enqueue(() =>
                {
                    switch(e.Name)
                    {
                        case "block.frag":
                            _bfShader.DetachShader(_blockFragShader);
                            _blockFragShader = Shader.FromFile(e.FullPath);
                            _bfShader.AttachShader(_blockFragShader);
                            break;
                        default:
                            return;
                    }
                    Trace.TraceInformation("Updating shader '{0}'", e.Name);
                        
                    _bfShader.Link();
                    _bfShader.Use();
                    _bfProjUniform = new Uniform(_bfShader, "ProjectionMatrix");
                    _bfSampler = new Uniform(_bfShader, "TexSampler");
                    _bfSampler.Set1(0);
                });
        }
        _shaderFileWatcher.EnableRaisingEvents = true;
    }
