    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    
    namespace Syscalls
    {
    
    
        public class Linux
        {
    
            // apt-get source util-linux
            // ./mount/loop.h
            // ./mount/mount.c
            // ./mount/lomount.c
            // ./include/linux_version.h
            // ./lib/linux_version.c
            // ./include/linux_reboot.h
    
    
    
            protected const int LOOP_SET_FD = 0x4C00;
            protected const int LOOP_CLR_FD = 0x4C01;
    
            protected const int LOOP_GET_STATUS = 0x4C03;
            protected const int LOOP_SET_STATUS = 0x4C02;
    
            protected const int LOOP_GET_STATUS64 = 0x4C05;
            protected const int LOOP_SET_STATUS64 = 0x4C04;
    
            protected const int LO_NAME_SIZE = 64;
            protected const int LO_KEY_SIZE = 32;
    
            protected const int PATH_MAX = 4096;
    
    
            // MS_RELATIME  //(default for Linux >= 2.6.30) 
            // MS_STRICTATIME //(default for Linux < 2.6.30) 
    
            // http://harmattan-dev.nokia.com/docs/library/html/manpages/headers/sys/mount.html
            public enum MountFlags : ulong
            {
                MS_RDONLY = 1,         // Mount read-only.
                MS_NOSUID = 2,         // Ignore suid and sgid bits.
                MS_NODEV = 4,         // Disallow access to device special files.
                MS_NOEXEC = 8,         // Disallow program execution.
                MS_SYNCHRONOUS = 16,    // Writes are synced at once.
                MS_REMOUNT = 32,    // Alter flags of a mounted FS.
                MS_MANDLOCK = 64,    // Allow mandatory locks on an FS.
                S_WRITE = 128,   // Write on file/directory/symlink.
                S_APPEND = 256,   // Append-only file.
                S_IMMUTABLE = 512,   // Immutable file.
                MS_NOATIME = 1024,  // Do not update access times.
                MS_NODIRATIME = 2048,  // Do not update directory access times.
                MS_BIND = 4096,  // Bind directory at different place.
            }; // End Enum MountFlags : ulong
    
            /*
            // http://unix.superglobalmegacorp.com/Net2/newsrc/sys/fcntl.h.html
            [Flags]
            protected enum OpenFlags : int
            {
                // open-only flags 
                O_RDONLY = 0x0000,		// open for reading only 
                O_WRONLY = 0x0001,		// open for writing only 
                O_RDWR = 0x0002,		// open for reading and writing 
                O_ACCMODE = 0x0003,		// mask for above modes 
    
                //#ifdef KERNEL
                FREAD = 0x0001,
                FWRITE = 0x0002,
                //#endif
                O_NONBLOCK = 0x0004,	// no delay 
                O_APPEND = 0x0008,		// set append mode 
                //#ifndef _POSIX_SOURCE
                O_SHLOCK = 0x0010,		// open with shared file lock 
                O_EXLOCK = 0x0020,		// open with exclusive file lock 
                O_ASYNC = 0x0040,		// signal pgrp when data ready 
                O_FSYNC = 0x0080,		// synchronous writes 
                //#endif
                O_CREAT = 0x0200,		// create if nonexistant 
                O_TRUNC = 0x0400,		// truncate to zero length 
                O_EXCL = 0x0800,		// error if already exists 
                //#ifdef KERNEL
                FMARK = 0x1000,			// mark during gc() 
                FDEFER = 0x2000,		// defer for next gc pass 
                FHASLOCK = 0x4000		// descriptor holds advisory lock 
            } // End Enum OpenFlags : int
            */
    
            [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
            protected struct loop_info
            {
                public int lo_number;
                public System.UIntPtr lo_device; //my_dev_t	lo_device; // my_dev_t: long unsigned int
                public System.UIntPtr lo_inode; //unsigned long	lo_inode;
                public System.UIntPtr lo_rdevice; //my_dev_t	lo_rdevice;// my_dev_t: long unsigned int
                public int lo_offset;
                public int lo_encrypt_type;
                public int lo_encrypt_key_size;
                public int lo_flags;
    
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = LO_NAME_SIZE)]
                public string lo_name; //char		lo_name[LO_NAME_SIZE];
    
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = LO_KEY_SIZE)]
                public string lo_encrypt_key; //unsigned char	lo_encrypt_key[LO_KEY_SIZE];
    
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 2)]
                public System.UIntPtr[] lo_init; //unsigned long	lo_init[2];
    
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 4)]
                public string reserved; //char		reserved[4];
            }; // End Struct loop_info
    
    
            protected struct loop_info64
            {
                public System.UInt64 lo_device;
                public System.UInt64 lo_inode;
                public System.UInt64 lo_rdevice;
                public System.UInt64 lo_offset;
                public System.UInt64 lo_sizelimit; /* bytes, 0 == max available */
                public System.UInt32 lo_number;
                public System.UInt32 lo_encrypt_type;
                public System.UInt32 lo_encrypt_key_size;
                public System.UInt32 lo_flags;
    
                // http://stackoverflow.com/questions/1725855/uint8-t-vs-unsigned-char
    
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = LO_NAME_SIZE)]
                public string lo_file_name; // uint8_t		lo_file_name[LO_NAME_SIZE];
    
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = LO_NAME_SIZE)]
                public string lo_crypt_name; // uint8_t		lo_crypt_name[LO_NAME_SIZE];
    
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = LO_KEY_SIZE)]
                public string lo_encrypt_key; // uint8_t		lo_encrypt_key[LO_KEY_SIZE];
    
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 2)]
                public System.UInt64[] lo_init;
            }; // End Struct loop_info64
    
    
            // http://www.student.cs.uwaterloo.ca/~cs350/common/os161-src-html/kern_2include_2kern_2stat_8h.html
            protected static bool S_ISBLK(int mode)
            {
                const uint S_IFMT = 070000;
                const uint S_IFBLK = 050000;
                return (((mode) & S_IFMT) == S_IFBLK);
            } // End Function S_ISBLK
    
    
            public static int KERNEL_VERSION()
            {
                Mono.Unix.Native.Utsname unameres = new Mono.Unix.Native.Utsname();
                Mono.Unix.Native.Syscall.uname(out unameres);
    
                System.Text.RegularExpressions.Match ma = System.Text.RegularExpressions.Regex.Match(unameres.release, @"(\d+).(\d+).(\d+)(-)?(\d+)?");
                string strMajor = ma.Groups[1].Value;
                string strMinor = ma.Groups[2].Value;
                string strTiny = ma.Groups[3].Value;
                string strPatchlevel = ma.Groups[5].Value;
    
                int a = System.Convert.ToInt32(strMajor);
                int b = System.Convert.ToInt32(strMinor);
                int c = System.Convert.ToInt32(strTiny);
    
                return KERNEL_VERSION(a, b, c);
            } // End Function KERNEL_VERSION
    
    
            //# define KERNEL_VERSION(a,b,c) (((a) << 16) + ((b) << 8) + (c))
            public static int KERNEL_VERSION(int a, int b, int c)
            {
                return (((a) << 16) + ((b) << 8) + (c));
            }
    
    
            public static string CreateVirtualDisk(int iSize)
            {
                string strBaseDirectory = @"/volumes/";
                string strFileName = System.Guid.NewGuid().ToString().Replace("-", "") + ".dsk";
    
                string strFileNameAndPath = System.IO.Path.Combine(strBaseDirectory, strFileName);
    
                using (var fs = new System.IO.FileStream(strFileNameAndPath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
                {
                    fs.SetLength(iSize);
                } // End Using fs
    
                return strFileNameAndPath;
            } // End Function CreateVirtualDisk
    
    
            // umount("/mnt/testdisk");
            public static bool umount(string strMountPoint)
            {
                int status = UnsafeNativeMethods.umount(strMountPoint);
    
                if (status == 0)
                    Console.WriteLine("Successfully unmounted device.");
                else
                    Console.WriteLine("Unmount status: " + status.ToString());
    
                if (status == 0)
                    return true;
    
                return false;
            } // End Function Unmount
    
    
            public static string find_unused_loop_device()
            {
                string dev;
                int fd;
                Mono.Unix.Native.Stat statbuf;
                loop_info loopinfo = new loop_info();
                loop_info64 lo64 = new loop_info64();
    
                for (int i = 0; i <= 7; i++)
                {
                    dev = "/dev/loop" + i.ToString();
    
                    if (System.Convert.ToBoolean(Mono.Unix.Native.Syscall.stat(dev, out statbuf)) == (false && S_ISBLK((int)statbuf.st_mode)))
                    {
                        
                        if ((fd = Mono.Unix.Native.Syscall.open(dev, Mono.Unix.Native.OpenFlags.O_RDONLY)) >= 0)
                        {
    
                            // This block was commented out initially
                            if (UnsafeNativeMethods.ioctl(fd, LOOP_GET_STATUS64, ref lo64) == 0)
                            {
                                if (Mono.Unix.Native.Syscall.GetLastError() == Mono.Unix.Native.Errno.ENXIO)
                                {	// probably free
                                    Mono.Unix.Native.Syscall.close(fd);
                                    return dev;
                                }
                            }
    
    
                            if (UnsafeNativeMethods.ioctl(fd, LOOP_GET_STATUS, ref loopinfo) != 0)
                            {
                                // http://tomoyo.sourceforge.jp/cgi-bin/lxr/source/include/asm-generic/errno-base.h#L9
                                // ENXIO - No such device or address
                                // The device accessed by a command is physically not present, 
                                // or the address of the device is not present
                                if (Mono.Unix.Native.Syscall.GetLastError() == Mono.Unix.Native.Errno.ENXIO)
                                {
                                    // that means the device is most-likely free
                                    Mono.Unix.Native.Syscall.close(fd);
                                    return dev;
                                }
    
                            } // End if (UnsafeNativeMethods.ioctl(fd, LOOP_GET_STATUS, ref loopinfo) != 0)
    
                            Mono.Unix.Native.Syscall.close(fd);
                        } // End if ((fd = UnsafeNativeMethods.open(dev, OpenFlags.O_RDONLY)) >= 0)
    
                    } // End if (System.Convert.ToBoolean(Mono.Unix.Native.Syscall.stat(dev, out statbuf)) == (false && S_ISBLK((int)statbuf.st_mode)))
    
                } // Next i
    
                return null;
            } // End Function find_unused_loop_device
    
    
            public static int set_loop(string device, string file, int offset, ref int loopro)
            {
                loop_info loopinfo = new loop_info();
                int fd = 0, ffd = 0;
                Mono.Unix.Native.OpenFlags mode;
    
                mode = loopro != 0 ? Mono.Unix.Native.OpenFlags.O_RDONLY : Mono.Unix.Native.OpenFlags.O_RDWR;
    
                if (
                        (
                            ffd = Mono.Unix.Native.Syscall.open(file, mode)
                        ) < 0
                        &&
                        (
                            (!System.Convert.ToBoolean((int)loopro))
                            &&
                            (
    
                                Mono.Unix.Native.Syscall.GetLastError() != Mono.Unix.Native.Errno.EROFS
                                ||
                                (ffd = Mono.Unix.Native.Syscall.open(file, mode = Mono.Unix.Native.OpenFlags.O_RDONLY))
                                < 0
                            )
                        )
                    ) // if
                {
                    Console.WriteLine("Error: file: " + file);
                    //perror_msg("%s", file);
                    return 1;
                } // End if
    
    
                if ((fd = Mono.Unix.Native.Syscall.open(device, mode)) < 0)
                {
                    Mono.Unix.Native.Syscall.close(ffd);
                    Console.WriteLine("Error: device: " + device);
                    //perror_msg("%s", device);
                    return 1;
                }
    
                loopro = System.Convert.ToInt32(mode == Mono.Unix.Native.OpenFlags.O_RDONLY);
                //memset(&loopinfo, 0, sizeof(loopinfo));
    
    
                //safe_strncpy(loopinfo.lo_name, file, LO_NAME_SIZE);
                //strncpy(loopinfo.lo_name, file, LO_NAME_SIZE);
                loopinfo.lo_name = string.IsNullOrEmpty(file) ? null : file.Substring(0, Math.Min(file.Length, LO_NAME_SIZE));
    
                loopinfo.lo_offset = offset;
                loopinfo.lo_encrypt_key_size = 0;
    
                if (UnsafeNativeMethods.ioctl(fd, LOOP_SET_FD, ffd) < 0)
                {
                    Console.WriteLine("ioctl: LOOP_SET_FD");
                    //perror_msg("ioctl: LOOP_SET_FD");
                    Mono.Unix.Native.Syscall.close(fd);
                    Mono.Unix.Native.Syscall.close(ffd);
                    return 1;
                }
    
                if (UnsafeNativeMethods.ioctl(fd, LOOP_SET_STATUS, ref loopinfo) < 0)
                {
                    int ro = 0;
                    UnsafeNativeMethods.ioctl(fd, LOOP_CLR_FD, ref ro);
                    //perror_msg("ioctl: LOOP_SET_STATUS");
                    Console.WriteLine("ioctl: LOOP_SET_STATUS");
                    Mono.Unix.Native.Syscall.close(fd);
                    Mono.Unix.Native.Syscall.close(ffd);
                    return 1;
                }
    
                Mono.Unix.Native.Syscall.close(fd);
                Mono.Unix.Native.Syscall.close(ffd);
                return 0;
            } // End Function set_loop
    
    
            public static int del_loop(string device)
            {
                int fd;
    
                if ((fd = Mono.Unix.Native.Syscall.open(device, Mono.Unix.Native.OpenFlags.O_RDONLY)) < 0)
                {
                    //perror_msg("%s", device);
                    Console.WriteLine("Error description: " + Mono.Unix.Native.Syscall.strerror(Mono.Unix.Native.Syscall.GetLastError()));
                    return 0;
                }
    
                int r = 0;
    
                if (UnsafeNativeMethods.ioctl(fd, LOOP_CLR_FD, ref r) < 0)
                {
                    //perror_msg("ioctl: LOOP_CLR_FD");
                    Console.WriteLine("ioctl: LOOP_CLR_FD\nError description: " + Mono.Unix.Native.Syscall.strerror(Mono.Unix.Native.Syscall.GetLastError()));
                    return 0;
                }
    
                Mono.Unix.Native.Syscall.close(fd);
                Console.WriteLine("Successfully closed loop-device\n");
                return 1;
            } // End Function del_loop
    
    
            public static bool mount(string strDevice, string strMountPoint, string strFsType)
            {
                return mount(strDevice, strMountPoint, strFsType, MountFlags.MS_NOATIME);
            }
    
            public static bool mount(string strDevice, string strMountPoint, string strFsType, MountFlags mflags)
            {
                return mount(strDevice, strMountPoint, strFsType, mflags, IntPtr.Zero);
            }
    
    
            // http://cboard.cprogramming.com/c-programming/126630-using-sys-mount-h-mounting-usb-thumb-drive.html
            // http://stackoverflow.com/questions/10458549/mount-usb-drive-in-linux-with-c
            // mount("/dev/loop1", "/mnt/testdisk", "vfat");
            public static bool mount(string strDevice, string strMountPoint, string strFsType, MountFlags mflags, IntPtr options)
            {
    
                // http://linux.die.net/man/2/mount
                // MS_RDONLY
                // MS_RELATIME (default for Linux >= 2.6.30) 
                // MS_STRICTATIME (default for Linux < 2.6.30) 
    
                if (UnsafeNativeMethods.mount(strDevice, strMountPoint, strFsType, mflags, options) != 0)
                {
                    Mono.Unix.Native.Errno errno = Mono.Unix.Native.Syscall.GetLastError();
    
                    if (errno == Mono.Unix.Native.Errno.EBUSY)
                    {
                        Console.WriteLine("Mountpoint busy");
                    }
                    else
                    {
                        Console.WriteLine("Mount error: " + Mono.Unix.Native.Syscall.strerror(errno));
                    }
    
                    return false;
                }
                else
                {
                    Console.WriteLine("Successfully mounted device !");
                }
    
                return true; ;
            } // End Function mount
    
    
            static class UnsafeNativeMethods
            {
    
    
                //string name = "Test";
                //TypedReference tf = __makeref(name);
                //int c = VarSum(2, __arglist(__makeref(name)));
    
    
                // http://khason.net/blog/how-to-pinvoke-varargs-variable-arguments-in-c-or-hidden-junk-in-clr/
                // //int rv = ioctl(2, 3, __arglist(5, 10));
                [System.Runtime.InteropServices.DllImportAttribute("libc", EntryPoint = "ioctl",
                CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
                public static extern int ioctl(int descriptor, int request, __arglist);
    
                [System.Runtime.InteropServices.DllImport("libc", SetLastError = true)]
                public static extern int ioctl(int d, int request, int data);
    
                [System.Runtime.InteropServices.DllImport("libc", SetLastError = true)]
                public static extern int ioctl(int d, int request, ref int data);
    
                [System.Runtime.InteropServices.DllImport("libc", SetLastError = true)]
                public static extern int ioctl(int d, int request, ref loop_info data);
    
                [System.Runtime.InteropServices.DllImport("libc", SetLastError = true)]
                public static extern int ioctl(int d, int request, ref loop_info64 data);
    
                //[System.Runtime.InteropServices.DllImport("libc", SetLastError = true)]
                //public static extern int open([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string pathname, OpenFlags flags);
    
                //[System.Runtime.InteropServices.DllImport("libc", SetLastError = true)]
                //public static extern int close(int fd);
    
                //[System.Runtime.InteropServices.DllImport("libc", SetLastError = true)]
                //public static extern IntPtr read(int fd, IntPtr buffer, UIntPtr count);
                ///////unsafe public static extern IntPtr read(int fd, void* buffer, UIntPtr count);
    
                // http://linux.die.net/man/2/mount
                // http://www.kernel.org/doc/man-pages/online/pages/man2/mount.2.html
                [System.Runtime.InteropServices.DllImport("libc", SetLastError = true)]
                private static extern int mount(string source, string target, string filesystemtype, UIntPtr mountflags, System.IntPtr data);
                //int mount(const char *source, const char *target, const char *filesystemtype, ulong mountflags, const void *data);
    
    
                public static int mount(string source, string target, string filesystemtype, MountFlags mountflags, System.IntPtr data)
                {
                    System.UIntPtr p = new System.UIntPtr((ulong)mountflags);
                    return mount(source, target, filesystemtype, p, data);
                } // End Function mount
    
    
                [System.Runtime.InteropServices.DllImport("libc", SetLastError = true)]
                public static extern int umount(string strMountPoint);
                // extern int umount (__const char *__special_file);
            } // End Class UnsafeNativeMethods
    
    
            public static void TryMount()
            {
                const bool SUCCESS = true;
    
                // int iReturnCode = Mono.Unix.Native.Syscall.system("mount -a");
                // int iReturnCode = Mono.Unix.Native.Syscall.system("mount /volumes/jfs.dsk /mnt/jfs -t jfs -o loop");
                // int iReturnCode = Mono.Unix.Native.Syscall.system("mkfs.jfs -O \"jfs.dsk\"");
    
                string strLoopDeviceToUse = find_unused_loop_device();
                string strMountPoint = "/mnt/testdisk";
    
                int ro = 0;
                set_loop(strLoopDeviceToUse, "/volumes/testdisk.dsk", 0, ref ro);
    
                string strLoopDeviceToUse2 = find_unused_loop_device();
    
                bool status = false;
                int mountAttempts = 0;
                do
                {
                    //status = mount("/dev/sda1", "/media/usb0", "vfat", MS_MGC_VAL | MS_NOSUID, "");
                    status = mount(strLoopDeviceToUse, strMountPoint, "vfat", MountFlags.MS_NOATIME);
    
                    if (status != SUCCESS)
                        System.Threading.Thread.Sleep(1000);
    
                    mountAttempts++;
                } while (status != SUCCESS && mountAttempts < 3);
    
            } // End Sub TryMount
    
    
    
            // In gcc or g++, to show all of the macros that are defined for a given platform:
            // gcc -dM -E test.c
            // or 
            // g++ -dM -E test.cpp
    
            // http://manual.cream.org/index.cgi/gnu_dev_major.3
            // http://www.gnu.org/software/gnulib/coverage/usr/include/sys/sysmacros.h.gcov.frameset.html
            // http://en.wikipedia.org/wiki/C_data_types
            protected static uint gnu_dev_major(System.UInt64 __dev)
            {
                return (uint)((uint)(((__dev >> 8) & 0xfff)) | ((uint)(__dev >> 32) & ~0xfff));
            }
    
            protected static uint gnu_dev_minor(System.UInt64 __dev)
            {
                return (uint)((uint)(__dev & 0xff) | ((uint)(__dev >> 12) & ~0xff));
            }
    
    
            public static string loopfile_from_sysfs(string device)
            {
                string res = null;
                Mono.Unix.Native.Stat st;
                System.IntPtr f;
    
                //if (stat(device, &st) || !S_ISBLK(st.st_mode))
                //if (System.Convert.ToBoolean(Mono.Unix.Native.Syscall.stat(device, out st)) || !S_ISBLK((int) st.st_mode))
                //	return null;
    
                Mono.Unix.Native.Syscall.stat(device, out st);
    
                const string _PATH_SYS_DEVBLOCK = "/sys/dev/block";
                string strPath = string.Format("{0}/{1}:{2}/loop/backing_file", _PATH_SYS_DEVBLOCK, gnu_dev_major(st.st_rdev), gnu_dev_minor(st.st_rdev));
    
                f = Mono.Unix.Native.Syscall.fopen(strPath, "r");
                if (f == IntPtr.Zero)
                    return null;
    
                Mono.Unix.Native.Syscall.fclose(f);
    
                res = System.IO.File.ReadAllText(strPath);
                strPath = null;
                return res;
            } // End Function loopfile_from_sysfs
    
    
            public static string loopdev_get_loopfile(string device)
            {
                string res = loopfile_from_sysfs(device);
    
                if (res == null)
                {
                    loop_info lo = new loop_info();
                    loop_info64 lo64 = new loop_info64();
    
                    int fd;
    
                    if ((fd = Mono.Unix.Native.Syscall.open(device, Mono.Unix.Native.OpenFlags.O_RDONLY)) < 0)
                        return null;
    
                    if (UnsafeNativeMethods.ioctl(fd, LOOP_GET_STATUS64, ref lo64) == 0)
                    {
                        //lo64.lo_file_name[LO_NAME_SIZE-2] = '*';
                        //lo64.lo_file_name[LO_NAME_SIZE-1] = 0;
                        //res = strdup((char *) lo64.lo_file_name);
                        res = lo64.lo_file_name;
                        Console.WriteLine("LOOP_GET_STATUS64");
    
                    }
                    else if (UnsafeNativeMethods.ioctl(fd, LOOP_GET_STATUS, ref lo) == 0)
                    {
                        //lo.lo_name[LO_NAME_SIZE-2] = '*';
                        //lo.lo_name[LO_NAME_SIZE-1] = 0;
                        //res = strdup((char *) lo.lo_name);
                        res = lo.lo_name;
                        Console.WriteLine("LOOP_GET_STATUS");
                    }
    
                    Mono.Unix.Native.Syscall.close(fd);
                } // End if (res == null)
    
                return res;
            } // End Function loopdev_get_loopfile
    
    
            public static void TryUnmount()
            {
                /*
                string strMountPoint = "/mnt/testdisk";
    			
                umount(strMountPoint);
                System.Threading.Thread.Sleep(1000);
                del_loop("/dev/loop2");
                */
                string xxx = loopdev_get_loopfile("/dev/loop0");
                Console.WriteLine("xxx: " + xxx);
            }
    
            // kernel-support:
            // grep hfs /proc/filesystems
            // cat /proc/partitions
    
            // apt-get install hfsprogs
            // sudo modprobe hfsplus
            // dd if=/dev/zero of=hfsplus.dsk bs=1048576 count=150
            // mkfs.hfsplus /volumes/hfsplus.dsk
            // mkfs.hfsplus hfsplus.dsk
    
    
            // apt-get install jfsutils
            // dd if=/dev/zero of=jfs.dsk bs=1048576 count=150
            // mkfs.jfs -O jfs.dsk
            // mkdir -p /mnt/jfs
            // mount /volumes/jfs.dsk /mnt/jfs -t jfs -o loop
            // umount /mnt/jfs/
    
    
            // mkdir -p /mnt/hfsplus
    
            // mount -t hfsplus /volumes/hfsplus.dsk /mnt/hfsplus/ -o loop
    
            // 	
        } // End Class Linux
    
    
    } // End Namespace Syscalls
    
    // http://ubuntuforums.org/showthread.php?t=135113
    // http://stackoverflow.com/questions/7027151/call-expect-script-in-c-process
    // http://linux.die.net/man/1/expect
    // http://linux.die.net/man/3/libexpect
    
    // http://linuxcommand.org/man_pages/losetup8.html
    // losetup /dev/loop0 /file
    // losetup -d /dev/loop0
    
    // http://linux.about.com/library/cmd/blcmdl8_losetup.htm
