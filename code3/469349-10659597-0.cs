    public Kernel newKernel() {
      Kernel kernel = new Kernel();
      Filesystem filesystem = new Filesystem();
      kernel.setFilesystem(filesystem);
      filesystem.setKernel(kernel);
      return kernel;
    }
    public Filesystem newFilesystem() {
      Kernel kernel = new Kernel();
      Filesystem filesystem = new Filesystem();
      kernel.setFilesystem(filesystem);
      filesystem.setKernel(kernel);
      return filesystem;
    }
