    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Threading;
    using System.Diagnostics;
    
    namespace FeatureConfigurator
    {
        public class ThreadSafeBitmapWrapper
        {
            public event EventHandler<EventArgs> onImageChanged;
            ReaderWriterLockSlim thisLock;
            
            Bitmap iImg;
    
            public ThreadSafeBitmapWrapper()
            {
                this.iImg = new Bitmap(1,1);
                this.thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
            }
    
            public ThreadSafeBitmapWrapper(Bitmap img)
            {
                this.iImg = img;
                this.thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
            }
    
            public Bitmap GetImage()
            {
                Bitmap img;
                this.thisLock.EnterReadLock();
                try
                {
                    img = this.iImg;
                }
                finally
                {
                    this.thisLock.ExitReadLock();
                }
                return img;
            }
    
            public void SetImage(Bitmap img)
            {
                bool success = true;
                this.thisLock.EnterWriteLock();
                try
                {
                    this.iImg = img;
                }
                catch
                {
                    success = false;
                }
                finally
                {
                    this.thisLock.ExitWriteLock();
                    if (onImageChanged != null && success)
                        onImageChanged(this, new EventArgs());
                }
            }
    
            public Bitmap CloneImage()
            {
                Bitmap clone;
                this.thisLock.EnterReadLock();
                try
                {
                    clone = new Bitmap(iImg);
                }
                finally
                {
                    this.thisLock.ExitReadLock();
                }
                return clone;
            }
    
            internal Bitmap CloneImage(Rectangle rectangle, System.Drawing.Imaging.PixelFormat pixelFormat)
            {
                Bitmap clone;
                this.thisLock.EnterReadLock();
                try
                {
                    Stopwatch w = new Stopwatch();
                    w.Restart();
                    Debug.WriteLine("clone " + w.ElapsedMilliseconds);
                    clone = iImg.Clone(rectangle, pixelFormat);
                    Debug.WriteLine("new BMP " + w.ElapsedMilliseconds);
                }
                finally
                {
                    this.thisLock.ExitReadLock();
                }
                return clone;
            }
    
            /// <summary>
            /// Code from Microsoft C# Help page: http://msdn.microsoft.com/en-us/library/aa457087.aspx
            /// </summary>
            /// <param name="section">The region on the containing image, which should be copied</param>
            /// <returns></returns>
            public Bitmap CloneImage(Rectangle section)
            {
                // Create the new bitmap and associated graphics object
                Bitmap bmp = new Bitmap(section.Width, section.Height);
                // Sets the lock to protect the copy procedure
                this.thisLock.EnterReadLock();
                try
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        // Draw the specified section of the source bitmap to the new one
                        g.DrawImage(iImg, 0, 0, section, GraphicsUnit.Pixel);
                    }
                }
                finally
                {
                    this.thisLock.ExitReadLock();
                }
                // Return the bitmap
                return bmp;
            }
        }
    }
