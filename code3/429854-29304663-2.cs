    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    namespace test.Models
    {
      public class CaptchaImageResult : ActionResult
      {
        public string GetCaptchaString(int length)
        {
            int intZero = '1';
            int intNine = '9';
            int intA = 'A';
            int intZ = 'Z';
            int intCount = 0;
            int intRandomNumber = 0;
            string strCaptchaString = "";
            Random random = new Random(System.DateTime.Now.Millisecond);
            while (intCount < length)
            {
                intRandomNumber = random.Next(intZero, intZ);
                if (((intRandomNumber >= intZero) && (intRandomNumber <= intNine) || (intRandomNumber >= intA) && (intRandomNumber <= intZ)))
                {
                    strCaptchaString = strCaptchaString + (char)intRandomNumber;
                    intCount = intCount + 1;
                }
            }
            return strCaptchaString;
        }
        public override void ExecuteResult(ControllerContext context)
        {
           
            Bitmap bmp = new Bitmap(100, 30);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Navy);
            string randomString = GetCaptchaString(6);
            context.HttpContext.Session["captchastring"] = randomString;
            //add noise , if dont want any noisy , then make it false.
            bool noisy = true;
            if (noisy)
            {
                var rand = new Random((int)DateTime.Now.Ticks);
                int i, r, x, y;
                var pen = new Pen(Color.Yellow);
                for (i = 1; i < 10; i++)
                {
                    pen.Color = Color.FromArgb(
                    (rand.Next(0, 255)),
                    (rand.Next(0, 255)),
                    (rand.Next(0, 255)));
                    r = rand.Next(0, (130 / 3));
                    x = rand.Next(0, 130);
                    y = rand.Next(0, 30);
                    int m = x - r;
                    int n = y - r;
                    g.DrawEllipse(pen, m, n, r, r);
                }
            }
            //end noise
            g.DrawString(randomString, new Font("Courier", 16), new SolidBrush(Color.WhiteSmoke), 2, 2);
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "image/jpeg";
            bmp.Save(response.OutputStream, ImageFormat.Jpeg);
            bmp.Dispose(); 
        }  
    }
