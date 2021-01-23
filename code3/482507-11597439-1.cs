    Mono.Unix.Native.Utsname results;
    var res = Mono.Unix.Native.Syscall.uname(out results);
    if(res != 0)
    {
      throw new Exception("Syscall failed!");
    }
