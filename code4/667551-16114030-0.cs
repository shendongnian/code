	using Gtk;
	using Cairo;
	using System;
	public class Paint : Gtk.Window
	{
		delegate void DrawShape(Cairo.Context ctx, PointD start, PointD end);
		ImageSurface surface;
		DrawingArea area;
		DrawShape Painter;
		PointD Start, End;
		bool isDrawing;
		bool isDrawingPoint;
		Button line;
		Button pen;
		public Paint() : base("Painting application")
		{
			surface = new ImageSurface(Format.Argb32, 500, 500);
			area = new DrawingArea();
			area.AddEvents(
				(int)Gdk.EventMask.PointerMotionMask
				|(int)Gdk.EventMask.ButtonPressMask
				|(int)Gdk.EventMask.ButtonReleaseMask);
			area.ExposeEvent += OnDrawingAreaExposed;
			area.ButtonPressEvent += OnMousePress;
			area.ButtonReleaseEvent += OnMouseRelease;
			area.MotionNotifyEvent += OnMouseMotion;
			DeleteEvent += delegate { Application.Quit(); };
			Painter = new DrawShape(DrawLine);
			Start = new PointD(0.0, 0.0);
			End = new PointD(500.0, 500.0);
			isDrawing = false;
			isDrawingPoint = false;
			SetDefaultSize(500, 500);
			SetPosition(WindowPosition.Center);
			VBox vbox = new VBox();
			vbox.Add(area);
			HBox hbox = new HBox();
			line = new Button("Line");
			pen = new Button("Pen");
			hbox.Add(line);
			hbox.Add(pen);
			Alignment halign = new Alignment(1, 0, 0, 0);
			halign.Add(hbox);
			vbox.Add(hbox);
			vbox.PackStart(halign, false, false, 3);
			line.Clicked += LineClicked;
			pen.Clicked += PenClicked;
			Add(vbox);
			Add(area);
			ShowAll();
		}
		void OnDrawingAreaExposed(object source, ExposeEventArgs args)
		{
			Cairo.Context ctx;
			using (ctx = Gdk.CairoHelper.Create(area.GdkWindow))
			{
				ctx.Source = new SurfacePattern(surface);
				ctx.Paint();
			}
			if (isDrawing)
			{
				using (ctx = Gdk.CairoHelper.Create(area.GdkWindow))
				{
					Painter(ctx, Start, End);
				}
			}
		}
		void OnMousePress(object source, ButtonPressEventArgs args)
		{
			Start.X = args.Event.X;
			Start.Y = args.Event.Y;
			End.X = args.Event.X;
			End.Y = args.Event.Y;
			isDrawing = true;
			area.QueueDraw();
		}
		void OnMouseRelease(object source, ButtonReleaseEventArgs args)
		{
			End.X = args.Event.X;
			End.Y = args.Event.Y;
			isDrawing = false;
			using (Context ctx = new Context(surface))
			{
				Painter(ctx, Start, End);
			}
			area.QueueDraw();
		}
		void OnMouseMotion(object source, MotionNotifyEventArgs args)
		{
			if (isDrawing)
			{
				End.X = args.Event.X;
				End.Y = args.Event.Y;
				if(isDrawingPoint)
				{
					using (Context ctx = new Context(surface))
					{
						Painter(ctx, Start, End);
					}
				}
				area.QueueDraw();
			}
		}
		void LineClicked(object sender, EventArgs args)
		{
			isDrawingPoint = false;
			Painter = new DrawShape(DrawLine);
		}
		void PenClicked(object sender, EventArgs args)
		{
			isDrawingPoint = true;
			Painter = new DrawShape(DrawPoint);
		}
		void DrawLine(Cairo.Context ctx, PointD start, PointD end)
		{
			ctx.MoveTo(start);
			ctx.LineTo(end);
			ctx.Stroke();
		}
		void DrawPoint(Cairo.Context ctx, PointD start, PointD end)
		{
			ctx.Rectangle(end, 1, 1);
			ctx.Stroke();
		}
		public static void Main()
		{
			Application.Init();
			new Paint();
			Application.Run();
		}
	}
