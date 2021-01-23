    using System;
    
    namespace PixelTest
    {
    	public unsafe struct Pixel
    	{
    		private int _color;
    
    		public Pixel(int color)
    		{
    			_color = color;
    		}
    
    		public int GetColor()
    		{
    			return _color;
    		}
    
    		public int GetR()
    		{
    			fixed(int* c = &_color)
    			{
    				return *((byte*)c + 2);
    			}
    		}
    	
    		public int GetG()
    		{
    			fixed(int* c = &_color)
    			{
    				return *((byte*)c + 1);
    			}
    		}
    
    		public int GetB()
    		{
    			fixed(int* c = &_color)
    			{
    				return *(byte*)c;
    			}
    		}
    
    		public void SetR(byte red)
    		{
    			fixed (int* c = &_color)
    			{
    				*((byte*)c + 2) = red;
    			}
    		}
    
    		public void SetG(byte green)
    		{
    			fixed (int* c = &_color)
    			{
    				*((byte*)c + 1) = green;
    			}
    		}
    
    		public void SetB(byte blue)
    		{
    			fixed (int* c = &_color)
    			{
    				*(byte*)c = blue;
    			}
    		}
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Pixel c = new Pixel(0xFFAABB);
    			Console.WriteLine("R-{0:X}, G-{1:X}, B-{2:X}", c.GetR(), c.GetG(), c.GetB());
    			c.SetR(0x1A);
    			c.SetG(0x2B);
    			c.SetB(0x3D);
    			Console.WriteLine("Color - {0:X}", c.GetColor());
    		}
    	}
    }
