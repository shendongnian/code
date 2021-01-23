    interface FilenameSupplier {
        String getName();
    }
    public void ReadGeneral(FilenameSupplier a_file, FileItemData a_fileItemData) {
        ...
        a_file.getName();
        ...
    }
    class ConcreteSupplier implements FilenameSupplier {
        private final FsFileGroupFile file;
        public ConcreteSupplier(FsFileGroupFile file) { this.file = file; }
        String getName() { return a_file.File.FullName; }
    }
